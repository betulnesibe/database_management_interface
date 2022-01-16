create database lawoffice_cet301final
use lawoffice_cet301final

create table tbl_clients(
client_id int primary key identity(1,1),
client_tc bigint, --If Turkish citizen this can be helpful in the legal procedures
client_name nvarchar(100) not null,
client_surname nvarchar(100) not null,
client_mail nvarchar(320), --since the maximum number of characters can be 320= 64 (mail adress) + 1 (@) + 255 (domain) for email
client_phone bigint, --since the maximum number of characters can be 15 for an telephone number
)

create table tbl_appointments(
appointment_id int primary key identity(1,1),
appointment_place nvarchar(400) not null, --to add the adress
appointment_time nvarchar(50) not null,
client_id int foreign key references tbl_clients(client_id)
)

create table tbl_casetypes(
casetype_id int primary key identity(1,1),
casetype nvarchar(100) not null,
)

create table tbl_courts(
court_id int primary key identity(1,1),
court_place nvarchar(200) not null,
court_phone bigint,
)

create table tbl_mainmerits(
merit_id int primary key identity(1,1),
merity_type nvarchar(200) not null,
)

create table tbl_cases(
case_id int primary key identity(1,1),
case_status bit, --1 if open, 0 if closed, null if not known
case_parties nvarchar(250),
case_merityear smallint not null, --since it is only year an int would take a lot of space unused
case_meritnumber smallint not null, --merit numbers are not large numbers, so smallint is enough
case_decisionyear smallint, --it can be null since the case may not be decided yet
case_decisionnumber smallint,
casetype_id int foreign key references tbl_casetypes(casetype_id),
court_id int foreign key references tbl_courts(court_id),
merit_id int foreign key references tbl_mainmerits(merit_id),
client_id int foreign key references tbl_clients(client_id),
)

create table tbl_trials(
trial_id int primary key identity(1,1),
trial_time nvarchar(50) not null,
court_id int foreign key references tbl_courts(court_id),
case_id int foreign key references tbl_cases(case_id),
)

create table tbl_documents(
document_id int primary key identity(1,1),
document_name nvarchar(150),
document_file nvarchar(1000),
case_id int foreign key references tbl_cases(case_id),
)

create table tbl_notices(
notice_id int primary key identity(1,1),
notice_date nvarchar(50) not null, --since only the date is important for countdown in notifications
notice_last nvarchar(50), --can be null since there is a general last date for notifications
notice_timer smallint,
case_id int foreign key references tbl_cases(case_id),
)
