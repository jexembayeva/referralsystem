-- Creation of route table
CREATE TABLE IF NOT EXISTS route (
  Id SERIAL,
  NameRu varchar(250) NOT NULL,
  NameEn varchar(250) NOT NULL,
  NameKk varchar(250) NOT NULL,
  FullNameRu varchar(250) NOT NULL,
  FullNameEn varchar(250) NOT NULL,
  FullNameKk varchar(250) NOT NULL,
  Distance  DECIMAL(20,3) NOT NULL,
  Comment varchar(250) NOT NULL,
  OpenReason varchar(250) NOT NULL,
  CloseReason varchar(250) NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdateToken varchar(250) NOT NULL,
  PRIMARY KEY (Id)
);