/*---------------------------Routes-----------------------------*/
CREATE TABLE IF NOT EXISTS alternative (
  Id SERIAL,
  NameRu varchar(250) NOT NULL,
  NameEn varchar(250) NOT NULL,
  NameKk varchar(250) NOT NULL,
  FullNameRu varchar(250) NOT NULL,
  FullNameEn varchar(250) NOT NULL,
  FullNameKk varchar(250) NOT NULL,
  VehicleCount INT NOT NULL,
  PeakInterval INT NOT NULL,
  OffPeakInterval INT NOT NULL,
  RouteId INT NOT NULL,
  AlternativeType INT NOT NULL,
  VehicleTypeId INT NOT NULL,
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  Status INT NOT NULL,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS dayperiodtype (
  Id SERIAL,
  Name varchar(250) NOT NULL,
  Direction INT,
  AuthorId INT NOT NULL,
  AlternativeId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS dedicatedlane (
  Id SERIAL,
  Name varchar(250) NOT NULL,
  PeakSpeed INT,
  OffPeakSpeed INT,
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS lad (
  Id SERIAL,
  Name varchar(250) NOT NULL,
  Comment varchar(250),
  Direction INT,
  Length INT,
  Stops INT,
  TransitTime INT,
  AlternativeId INT NOT NULL,
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  Status INT NOT NULL,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS ladstop (
  Id SERIAL,
  StopOrder INT,
  Distance INT,
  IsControlPoint boolean NOT NULL,
  IsEnding boolean NOT NULL,
  PassCount INT,
  HasLunch boolean NOT NULL,
  AlternativeId INT NOT NULL,
  LadId INT NOT NULL,
  Direction INT,
  StopId INT,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

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
  WorkSeason INT NOT NULL,
  RouteCategory INT NOT NULL,
  RouteType INT NOT NULL,
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  Status INT NOT NULL,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS routeplan (
  Id SERIAL,
  Name varchar(250),
  RouteId INT NOT NULL,
  RoundCount INT,
  StartTime TIMESTAMPTZ,
  EndTime TIMESTAMPTZ,
  Interval INT,
  Comment varchar(250),
  DurationAB INT,
  DurationBA INT,
  Capacity INT,
  MaxStopTime INT,
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS routeschedule (
  Id SERIAL,
  Name varchar(250) NOT NULL,
  RouteId INT NOT NULL,
  Comment varchar(250) NOT NULL,
  StartTime TIMESTAMPTZ,
  EndTime TIMESTAMPTZ,
  Interval TIMESTAMPTZ,
  TimeLineCount TIMESTAMPTZ,
  DayType INT NOT NULL,
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS device (
  Id SERIAL,
  FirmWareId INT,
  StabilizerId INT,
  SimcardId INT,
  IMEI INT,
  SerialNumber varchar(250),
  Comment varchar(250),
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS firmware (
  Id SERIAL,
  Name varchar(250),
  Config varchar(250),
  Comment varchar(250),
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS simcard (
  Id SERIAL,
  SerialNumber varchar(250),
  PhoneNumber varchar(250),
  PIN1 varchar(250),
  PIN2 varchar(250),
  PUK1 varchar(250),
  PUK2 varchar(250),
  Comment varchar(250),
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS stabilizer (
  Id SERIAL,
  Name varchar(250),
  Comment varchar(250),
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

/*---------------------------Providers-----------------------------*/

CREATE TABLE IF NOT EXISTS city (
  Id SERIAL,
  NameRu varchar(250),
  NameEn varchar(250),
  NameKk varchar(250),
  RegionId INT NOT NULL,
  Comment varchar(250),
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS district (
  Id SERIAL,
  NameRu varchar(250),
  NameEn varchar(250),
  NameKk varchar(250),
  Polygon DECIMAL(20,3) NOT NULL,
  Color varchar(250),
  RegionId INT NOT NULL,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS provider (
  Id SERIAL,
  NameRu varchar(250) NOT NULL,
  NameEn varchar(250) NOT NULL,
  NameKk varchar(250) NOT NULL,
  Address varchar(250) NOT NULL,
  Head varchar(250) NOT NULL,
  PhoneNumber varchar(250) NOT NULL,
  Email varchar(250) NOT NULL,
  Bank varchar(250) NOT NULL,
  BIN varchar(250) NOT NULL,
  BIK varchar(250) NOT NULL,
  DispatcherPhoneNumber varchar(250) NOT NULL,
  TechServicePhoneNumber varchar(250) NOT NULL,
  Comment varchar(250) NOT NULL,
  RegionId INT NOT NULL,
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS region (
  Id SERIAL,
  NameRu varchar(250),
  NameEn varchar(250),
  NameKk varchar(250),
  Comment varchar(250),
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS segment (
  Id SERIAL,
  Length int NOT NULL,
  LineCount INT,
  ParkingAllowed boolean NOT NULL,
  MaxSpeed INT,
  OneWay boolean NOT NULL,
  Direction INT,
  RailCrossing boolean NOT NULL,
  DedicatedLaneId INT,
  DirectDirectionLaneCount INT,
  ReverseDirectionLaneCount INT,
  DirectDirectionDedicatedLaneCount INT,
  ReverseDirectionDedicatedLaneCount INT,
  HasPublicTransport boolean NOT NULL,
  TurnRestrictions varchar(250) NOT NULL,
  Geometry  DECIMAL(20,3),
  Comment varchar(250) NOT NULL,
  DistrictId INT,
  StreetId INT,
  RouteId INT NOT NULL,
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  Status INT NOT NULL,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS street (
  Id SERIAL,
  NameRu varchar(250),
  NameEn varchar(250),
  NameKk varchar(250),
  Comment varchar(250),
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

/*---------------------------Stops-----------------------------*/

CREATE TABLE IF NOT EXISTS stop (
  Id SERIAL,
  NameRu varchar(250) NOT NULL,
  NameEn varchar(250) NOT NULL,
  NameKk varchar(250) NOT NULL,
  Longitude  DECIMAL(20,3),
  Latitude  DECIMAL(20,3),
  Direction  DECIMAL(20,3),
  Comment varchar(250) NOT NULL,
  HasStopZone boolean NOT NULL,
  HasLongStopZone boolean NOT NULL,
  DistrictId INT,
  SegmentId INT,
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

/*---------------------------Vehicles-----------------------------*/

CREATE TABLE IF NOT EXISTS vehiclebase (
  Id SERIAL,
  NameRu varchar(250),
  NameEn varchar(250),
  NameKk varchar(250),
  Polygon DECIMAL(20,3) NOT NULL,
  ProviderId INT,
  Comment varchar(250),
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS manufacturer (
  Id SERIAL,
  NameRu varchar(250),
  Country varchar(250),
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS vehicle (
  Id SERIAL,
  Model varchar(250) NOT NULL,
  Year int NOT NULL,
  DeviceId INT,
  ProviderId INT,
  IsOwned boolean NOT NULL,
  ManufacturerId INT,
  TransportMode INT,
  Status INT NOT NULL,
  Comment varchar(250) NOT NULL,
  PhoneNumber varchar(250) NOT NULL,
  LicencePlate varchar(250) NOT NULL,
  BaseId INT,
  FuelConsumptionRate INT,
  FuelConsumptionRateWinter INT,
  ValidFrom TIMESTAMPTZ,
  ValidTo TIMESTAMPTZ,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS vehiclecomfort (
  Id SERIAL,
  Name varchar(250),
  HasAirCon boolean NOT NULL,
  HasRampant boolean NOT NULL,
  Doors INT,
  FloorType INT,
  SeatType INT,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS vehiclesize (
  Id SERIAL,
  Name varchar(250),
  Seats INT,
  Capacity INT,
  Square INT,
  AuthorId INT NOT NULL,
  EditorId INT NOT NULL,
  CreatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  UpdatedAt TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  PRIMARY KEY (Id)
);
