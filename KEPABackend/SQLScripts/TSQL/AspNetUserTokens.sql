CREATE TABLE JWTAuthDB.dbo.AspNetUserTokens (
  UserId nvarchar(450) NOT NULL,
  LoginProvider nvarchar(450) NOT NULL,
  Name nvarchar(450) NOT NULL,
  Value nvarchar(max) NULL,
  CONSTRAINT PK_AspNetUserTokens PRIMARY KEY CLUSTERED (UserId, LoginProvider, Name)
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE JWTAuthDB.dbo.AspNetUserTokens
  ADD CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES dbo.AspNetUsers (Id) ON DELETE CASCADE
GO