CREATE TABLE JWTAuthDB.dbo.AspNetRoleClaims (
  Id int IDENTITY,
  RoleId nvarchar(450) NOT NULL,
  ClaimType nvarchar(max) NULL,
  ClaimValue nvarchar(max) NULL,
  CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

CREATE INDEX IX_AspNetRoleClaims_RoleId
  ON JWTAuthDB.dbo.AspNetRoleClaims (RoleId)
  ON [PRIMARY]
GO

ALTER TABLE JWTAuthDB.dbo.AspNetRoleClaims
  ADD CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES dbo.AspNetRoles (Id) ON DELETE CASCADE
GO