CREATE TABLE JWTAuthDB.dbo.AspNetRoles (
  Id nvarchar(450) NOT NULL,
  Name nvarchar(256) NULL,
  NormalizedName nvarchar(256) NULL,
  ConcurrencyStamp nvarchar(max) NULL,
  CONSTRAINT PK_AspNetRoles PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

CREATE UNIQUE INDEX RoleNameIndex
  ON JWTAuthDB.dbo.AspNetRoles (NormalizedName)
  WHERE ([NormalizedName] IS NOT NULL)
  ON [PRIMARY]
GO