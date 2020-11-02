create database ozi_lab3; --��������� ���� ����� ��� ����������� ������

--1. ��������� ����� �������� ������ Bill �� John
create login Bill
 with password = '1993Clinton2001',
 default_database = ozi_lab3;

create login John
 with password = '1797Adams1801',
 default_database = ozi_lab3;

create user Bill for login Bill;
create user John for login John;

 --2. ���������� ������������ Bill �� John ��� Controllers
	-- ��������� ��� Controllers
create role Controllers;
	-- ��������� ������������ �� ���
execute sp_addrolemember "Controllers", "Bill";
execute sp_addrolemember "Controllers", "John";

--3. ������� ����������� Bill ������� �� ��������� ���������
--   [sys].[sp_add_agent_parameter]
grant execute on object::[sys].[sp_add_agent_parameter]  
    to Bill;
	
--4. ³��������� ��� ������� ����������� John ��������
revoke all from John;

-- ��������� �� ��������� ������ � ������� ��� ����������
create table Users (
	username varchar(50) not null,
	password_enc varchar(50) not null
	);

insert Users values ('Olesia', 'Olesia,24');

select * from Users;

-- �������� ����������� ������, ��� ����� ���� ���� � �������
-- ������� � �������� ��.

-- 1.�������� �������� ������-����� ���������� �������
use master;
select *
from sys.symmetric_keys
where name = '##MS_ServiceMasterKey##';
-- 2.��������� ������-����� ���� �����
create master key encryption by password = 'Password123';
-- 3.��������� �����������
create certificate Certificate1
with subject = 'Protect Data';
-- 4.��������� ������������ �����
create symmetric key SymmetricKey1
	with algorithm = AES_128
encryption by certificate Certificate1;
-- 5.���� ����� �����
alter table Users
	add password_encrypt varbinary(MAX) NULL;--��������� ������� ���� varbinary
open symmetric key SymmetricKey1
	decryption by certificate Certificate1;
-- 6.���������� ������� �������
update Users
set password_encrypt = EncryptByKey
(Key_GUID('SymmetricKey1'),password_enc)
from dbo.Users;
-- 7.��������� ������������� �������
alter table Users
drop column password_enc;
-- 8. ���������
select username, password_encrypt AS 'Encrypted password',
CONVERT(varchar, DecryptByKey(password_encrypt))
as 'Decrypted password'
from dbo.Users;
close symmetric key SymmetricKey1;