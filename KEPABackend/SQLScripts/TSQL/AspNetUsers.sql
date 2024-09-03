CREATE TABLE JWTAuthDB.dbo.AspNetUsers (
  Id nvarchar(450) NOT NULL,
  UserName nvarchar(256) NULL,
  NormalizedUserName nvarchar(256) NULL,
  Email nvarchar(256) NULL,
  NormalizedEmail nvarchar(256) NULL,
  EmailConfirmed bit NOT NULL,
  PasswordHash nvarchar(max) NULL,
  SecurityStamp nvarchar(max) NULL,
  ConcurrencyStamp nvarchar(max) NULL,
  PhoneNumber nvarchar(max) NULL,
  PhoneNumberConfirmed bit NOT NULL,
  TwoFactorEnabled bit NOT NULL,
  LockoutEnd datetimeoffset NULL,
  LockoutEnabled bit NOT NULL,
  AccessFailedCount int NOT NULL,
  CONSTRAINT PK_AspNetUsers PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

CREATE INDEX EmailIndex
  ON JWTAuthDB.dbo.AspNetUsers (NormalizedEmail)
  ON [PRIMARY]
GO

CREATE UNIQUE INDEX UserNameIndex
  ON JWTAuthDB.dbo.AspNetUsers (NormalizedUserName)
  WHERE ([NormalizedUserName] IS NOT NULL)
  ON [PRIMARY]
GO