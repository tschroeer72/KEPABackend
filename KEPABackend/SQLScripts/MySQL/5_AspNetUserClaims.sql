-- SQLINES FOR EVALUATION USE ONLY (14 DAYS)
CREATE TABLE d03c455b.AspNetUserClaims (
  Id int AUTO_INCREMENT,
  UserId nvarchar(450) NOT NULL,
  ClaimType longtext NULL,
  ClaimValue longtext NULL,
  CONSTRAINT PK_AspNetUserClaims PRIMARY KEY (Id)
)
;

CREATE INDEX IX_AspNetUserClaims_UserId
  ON d03c455b.AspNetUserClaims (UserId)
;
 

ALTER TABLE d03c455b.AspNetUserClaims
  ADD CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE;
 