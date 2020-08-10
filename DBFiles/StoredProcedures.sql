

create procedure [dbo].[SelectAllUsers]
as
	select * from Users
go

create procedure [dbo].[SelectAllPhoneNumbers]
as
	select * from PhoneNumbers
go

create procedure [dbo].[InsertIntoUsers]
	@name nvarchar(50),
	@addressBookID int
as
	INSERT INTO Users VALUES(@name, @addressBookID)
go

create procedure [dbo].[InsertIntoPhoneNumbers]
	@phoneNumber nchar(10),
	@isActive bit,
	@userID int
as
	INSERT INTO PhoneNumbers VALUES(@phoneNumber, @isActive, @userID)
go

create procedure [dbo].[SelectUserById]
	@id int
as
	SELECT * FROM Users WHERE ID = @id
go

create procedure [dbo].[SelectPhoneNumberById]
	@id int
as
	SELECT * FROM PhoneNumbers WHERE ID = @id
go

create procedure [dbo].[UpdateUser]
	@id int,
	@name nvarchar(50),
	@addressBookID int
as
	UPDATE Users SET Name = @name, AddressBookID = @addressBookID WHERE ID = @id
go

create procedure [dbo].[UpdatePhoneNumber]
	@id int,
	@phoneNumber nchar(10),
	@isActive bit,
	@userID int
as
	UPDATE PhoneNumbers SET PhoneNumber = @phoneNumber, IsActive = @isActive, UserID = @userID WHERE ID = @id
go

create procedure [dbo].[DeleteUserById]
	@id int
as
	DELETE Users WHERE ID = @id
go

create procedure [dbo].[DeletePhoneNumberById]
	@id int
as
	DELETE PhoneNumbers WHERE ID = @id
go

create procedure [dbo].[SelectUsersAndPhoneNumbersFromAddressBook]
	@addressBookId int
as
	SELECT Name, PhoneNumber, IsActive FROM Users LEFT JOIN PhoneNumbers on PhoneNumbers.UserID = Users.ID where AddressBookID = @addressBookId
go