create database ozi_lab3; --створення бази даних для лабораторної роботи

--1. Створення нових облікових засобів Bill та John
create login Bill
 with password = '1993Clinton2001',
 default_database = ozi_lab3;

create login John
 with password = '1797Adams1801',
 default_database = ozi_lab3;

create user Bill for login Bill;
create user John for login John;

 --2. Назначення користувачам Bill та John ролі Controllers
	-- Створення ролі Controllers
create role Controllers;
	-- Додавання користувачів до ролі
execute sp_addrolemember "Controllers", "Bill";
execute sp_addrolemember "Controllers", "John";

--3. Надання користувачу Bill доступу до збереженої процедури
--   [sys].[sp_add_agent_parameter]
grant execute on object::[sys].[sp_add_agent_parameter]  
    to Bill;
	
--4. Відкликання всіх наданих користувачу John привілегій
revoke all from John;

-- створення та додавання данних у таблицю для шифрування
create table Users (
	username varchar(50) not null,
	password_enc varchar(50) not null
	);

insert Users values ('Olesia', 'Olesia,24');

select * from Users;

-- Напишіть послідовність команд, яка шифрує вміст однієї з колонок
-- таблиці в створеній БД.

-- 1.перевірка наявності мастер-ключа екземпляру сервера
use master;
select *
from sys.symmetric_keys
where name = '##MS_ServiceMasterKey##';
-- 2.створення мастер-ключа бази даних
create master key encryption by password = 'Password123';
-- 3.створення сертифікату
create certificate Certificate1
with subject = 'Protect Data';
-- 4.створення симетричного ключа
create symmetric key SymmetricKey1
	with algorithm = AES_128
encryption by certificate Certificate1;
-- 5.зміна схеми даних
alter table Users
	add password_encrypt varbinary(MAX) NULL;--додавання колонки типу varbinary
open symmetric key SymmetricKey1
	decryption by certificate Certificate1;
-- 6.шифрування колонки таблиці
update Users
set password_encrypt = EncryptByKey
(Key_GUID('SymmetricKey1'),password_enc)
from dbo.Users;
-- 7.видалення незашифрованої колонки
alter table Users
drop column password_enc;
-- 8. результат
select username, password_encrypt AS 'Encrypted password',
CONVERT(varchar, DecryptByKey(password_encrypt))
as 'Decrypted password'
from dbo.Users;
close symmetric key SymmetricKey1;