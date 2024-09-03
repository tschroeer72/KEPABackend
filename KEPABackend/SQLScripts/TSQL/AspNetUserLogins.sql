CREATE TABLE JWTAuthDB.dbo.AspNetUserLogins (
  LoginProvider nvarchar(450) NOT NULL,
  ProviderKey nvarchar(450) NOT NULL,
  ProviderDisplayName nvarchar(max) NULL,
  UserId nvarchar(450) NOT NULL,
  CONSTRAINT PK_AspNetUserLogins PRIMARY KEY CLUSTERED (LoginProvider, ProviderKey)
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

CREATE INDEX IX_AspNetUserLogins_UserId
  ON JWTAuthDB.dbo.AspNetUserLogins (UserId)
  ON [PRIMARY]
GO

ALTER TABLE JWTAuthDB.dbo.AspNetUserLogins
  ADD CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES dbo.AspNetUsers (Id) ON DELETE CASCADE
GO