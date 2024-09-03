-- SQLINES FOR EVALUATION USE ONLY (14 DAYS)
CREATE TABLE d03c455b.AspNetUserTokens (
  UserId varchar(250) NOT NULL,
  LoginProvider varchar(250) NOT NULL,
  Name varchar(250) NOT NULL,
  Value longtext NULL,
  CONSTRAINT PK_AspNetUserTokens PRIMARY KEY (UserId, LoginProvider, Name)
)
;

ALTER TABLE d03c455b.AspNetUserTokens
  ADD CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE;
 