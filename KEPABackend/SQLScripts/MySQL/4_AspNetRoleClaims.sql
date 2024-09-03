-- SQLINES FOR EVALUATION USE ONLY (14 DAYS)
CREATE TABLE d03c455b.AspNetRoleClaims (
  Id int AUTO_INCREMENT,
  RoleId nvarchar(450) NOT NULL,
  ClaimType longtext NULL,
  ClaimValue longtext NULL,
  CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY (Id)
)
;

CREATE INDEX IX_AspNetRoleClaims_RoleId
  ON d03c455b.AspNetRoleClaims (RoleId)
;
 

ALTER TABLE d03c455b.AspNetRoleClaims
  ADD CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES AspNetRoles (Id) ON DELETE CASCADE;
 