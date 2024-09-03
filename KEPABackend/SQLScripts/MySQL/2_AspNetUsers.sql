-- SQLINES FOR EVALUATION USE ONLY (14 DAYS)
CREATE TABLE d03c455b.AspNetUsers (
  Id nvarchar(450) NOT NULL,
  UserName nvarchar(256) NULL,
  NormalizedUserName nvarchar(256) NULL,
  Email nvarchar(256) NULL,
  NormalizedEmail nvarchar(256) NULL,
  EmailConfirmed tinyint NOT NULL,
  PasswordHash longtext NULL,
  SecurityStamp longtext NULL,
  ConcurrencyStamp longtext NULL,
  PhoneNumber longtext NULL,
  PhoneNumberConfirmed tinyint NOT NULL,
  TwoFactorEnabled tinyint NOT NULL,
  LockoutEnd datetime(6) NULL,
  LockoutEnabled tinyint NOT NULL,
  AccessFailedCount int NOT NULL,
  CONSTRAINT PK_AspNetUsers PRIMARY KEY (Id)
)
;

CREATE INDEX EmailIndex
  ON d03c455b.AspNetUsers (NormalizedEmail)
;
 

CREATE UNIQUE INDEX UserNameIndex
  ON d03c455b.AspNetUsers (NormalizedUserName)
  WHERE (`NormalizedUserName` IS NOT NULL)
  ON [PRIMARY]
GO