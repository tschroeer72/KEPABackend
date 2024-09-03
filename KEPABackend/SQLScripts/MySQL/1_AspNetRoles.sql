-- SQLINES FOR EVALUATION USE ONLY (14 DAYS)
CREATE TABLE d03c455b.AspNetRoles (
  Id nvarchar(450) NOT NULL,
  Name nvarchar(256) NULL,
  NormalizedName nvarchar(256) NULL,
  ConcurrencyStamp longtext NULL,
  CONSTRAINT PK_AspNetRoles PRIMARY KEY (Id)
)
;

CREATE UNIQUE INDEX RoleNameIndex
  ON d03c455b.AspNetRoles (NormalizedName)
  WHERE (`NormalizedName` IS NOT NULL)
  ON [PRIMARY]
GO