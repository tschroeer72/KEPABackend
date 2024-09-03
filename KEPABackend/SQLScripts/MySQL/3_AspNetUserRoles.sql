-- SQLINES FOR EVALUATION USE ONLY (14 DAYS)
CREATE TABLE d03c455b.AspNetUserRoles (
  UserId nvarchar(450) NOT NULL,
  RoleId nvarchar(450) NOT NULL,
  CONSTRAINT PK_AspNetUserRoles PRIMARY KEY (UserId, RoleId)
)
;

CREATE INDEX IX_AspNetUserRoles_RoleId
  ON d03c455b.AspNetUserRoles (RoleId)
;
 

ALTER TABLE d03c455b.AspNetUserRoles
  ADD CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES AspNetRoles (Id) ON DELETE CASCADE;
 

ALTER TABLE d03c455b.AspNetUserRoles
  ADD CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE;
 