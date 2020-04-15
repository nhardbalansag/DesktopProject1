CREATE database final;

CREATE TABLE IF NOT EXISTS `dbt_building_information` (
    `buildingInformationID` INT(11) NOT NULL AUTO_INCREMENT,
    `buildingInfoName` VARCHAR(45) NOT NULL,
    `buildingInfoNumber` INT(11) NOT NULL,
    `buildingInfoStreet` VARCHAR(40) NOT NULL,
    `buildingInfoBarangay` VARCHAR(40) NOT NULL,
    `buildingInfoCity` VARCHAR(45) NOT NULL,
    PRIMARY KEY (`buildingInformationID`)
);


CREATE TABLE IF NOT EXISTS `dbt_floor_number` (
    `dbt_floorNumberId` INT(11) NOT NULL AUTO_INCREMENT,
    `floorTypeNumber` VARCHAR(10) NOT NULL,
    PRIMARY KEY (`dbt_floorNumberId`)
);

CREATE TABLE IF NOT EXISTS `dbt_job_position` (
    `dbt_jobPositionId` INT(11) NOT NULL AUTO_INCREMENT,
    `jobPositionTittle` VARCHAR(100) NOT NULL,
    PRIMARY KEY (`dbt_jobPositionId`)
);


CREATE TABLE IF NOT EXISTS `dbt_personal_information` (
    `dbt_personalInfoId` INT(11) NOT NULL AUTO_INCREMENT,
    `personalInfoFirstName` VARCHAR(100) NOT NULL,
    `personalInfoProfilePicture` LONGBLOB,
    `personalInfomiddleName` VARCHAR(100) NOT NULL,
    `personalInfoLastName` VARCHAR(100) NOT NULL,
    `personalInfoBirthday` DATETIME NOT NULL,
    `personalInfosex` VARCHAR(7) NOT NULL,
    `dbt_jobPosition` VARCHAR(50) NOT NULL,
    `registerUsername` VARCHAR(45) NOT NULL,
    `registerPassword` VARCHAR(45) NOT NULL,
    `login_status` INT(11) NOT NULL,
    PRIMARY KEY (`dbt_personalInfoId`)
);

CREATE TABLE IF NOT EXISTS `dbt_submeter` (
    `submeterId` INT(11) NOT NULL AUTO_INCREMENT,
    `submeter_type_name` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`submeterId`)
);


CREATE TABLE IF NOT EXISTS `dbt_tenants` (
    `tenantsId` INT(11) NOT NULL AUTO_INCREMENT,
    `tenantCompanyname` VARCHAR(100) NOT NULL,
    `floorNumber` VARCHAR(20) NOT NULL,
    `floorTypeCategorytype` VARCHAR(100) NOT NULL,
    `floorSubmetertype` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`tenantsId`)
);

CREATE TABLE IF NOT EXISTS `dbt_utilities_assigned_personnel` (
    `personnelId` INT(11) NOT NULL AUTO_INCREMENT,
    `personnelFirstName` VARCHAR(50) NOT NULL,
    `personnelLastName` VARCHAR(50) NOT NULL,
    `personnelMiddleName` VARCHAR(50) NOT NULL,
    `personnelSex` VARCHAR(6) NOT NULL,
    `personnelAddressRoomBldgName` VARCHAR(100) NOT NULL,
    `personnelAddressHouseBlockNum` VARCHAR(100) NOT NULL,
    `personnelAddressStreet` VARCHAR(100) NOT NULL,
    `personnelAddressSubdivision` VARCHAR(100) NOT NULL,
    `personnelAddressCity` VARCHAR(100) NOT NULL,
    `personnelBday` DATE NOT NULL,
    `dbt_jobPosition` VARCHAR(50) NOT NULL,
    `personnelPhoto` LONGBLOB NOT NULL,
    PRIMARY KEY (`personnelId`)
);


CREATE TABLE IF NOT EXISTS `dbt_utilities_type` (
    `utilitesTypeId` INT(11) NOT NULL AUTO_INCREMENT,
    `utilitesTypeName` VARCHAR(20) NOT NULL,
    `utilitesProvider` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`utilitesTypeId`)
);

CREATE TABLE IF NOT EXISTS `dbt_utilities_reading` (
    `utilitiesReadingId` INT(11) NOT NULL AUTO_INCREMENT,
    `personnelId` INT(11) NOT NULL,
    `utilitiesTypeId` INT(11) NOT NULL,
    `utilityReadingDate` DATETIME NOT NULL,
    `utilityCurrentReading` INT(11) NOT NULL,
    `utilityPrevReading` INT(11) NOT NULL,
    `utilityTotalReading` INT(11) NOT NULL,
    `tenantsId` INT(11) NOT NULL,
    `readingNotes` TEXT NOT NULL,
    PRIMARY KEY (`utilitiesReadingId`),
    FOREIGN KEY (`personnelId`)
        REFERENCES `dbt_utilities_assigned_personnel` (`personnelId`),
    FOREIGN KEY (`utilitiesTypeId`)
        REFERENCES `dbt_utilities_type` (`utilitesTypeId`),
    FOREIGN KEY (`tenantsId`)
        REFERENCES `dbt_tenants` (`tenantsId`)
);

