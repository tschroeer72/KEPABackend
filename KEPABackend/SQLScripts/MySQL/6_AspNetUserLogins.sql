-- SQLINES FOR EVALUATION USE ONLY (14 DAYS)
CREATE TABLE d03c455b.AspNetUserLogins (
  LoginProvider nvarchar(450) NOT NULL,
  ProviderKey nvarchar(450) NOT NULL,
  ProviderDisplayName longtext NULL,
  UserId nvarchar(450) NOT NULL,
  CONSTRAINT PK_AspNetUserLogins PRIMARY KEY (LoginProvider, ProviderKey)
)
;

CREATE INDEX IX_AspNetUserLogins_UserId
  ON d03c455b.AspNetUserLogins (UserId)
;
 

ALTER TABLE d03c455b.AspNetUserLogins
  ADD CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE;
 