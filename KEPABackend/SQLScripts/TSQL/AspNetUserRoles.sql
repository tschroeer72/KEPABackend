CREATE TABLE JWTAuthDB.dbo.AspNetUserRoles (
  UserId nvarchar(450) NOT NULL,
  RoleId nvarchar(450) NOT NULL,
  CONSTRAINT PK_AspNetUserRoles PRIMARY KEY CLUSTERED (UserId, RoleId)
)
ON [PRIMARY]
GO

CREATE INDEX IX_AspNetUserRoles_RoleId
  ON JWTAuthDB.dbo.AspNetUserRoles (RoleId)
  ON [PRIMARY]
GO

ALTER TABLE JWTAuthDB.dbo.AspNetUserRoles
  ADD CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES dbo.AspNetRoles (Id) ON DELETE CASCADE
GO

ALTER TABLE JWTAuthDB.dbo.AspNetUserRoles
  ADD CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES dbo.AspNetUsers (Id) ON DELETE CASCADE
GO