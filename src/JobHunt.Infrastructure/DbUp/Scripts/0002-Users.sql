INSERT INTO [AspNetUsers] (
    [Id], 
    [UserName], 
    [Email], 
    [PasswordHash], 
    [AccessFailedCount], 
    [ConcurrencyStamp], 
    [EmailConfirmed],
    [LockoutEnabled], 
    [LockoutEnd], 
    [NormalizedEmail], 
    [NormalizedUserName], 
    [PhoneNumber],
    [PhoneNumberConfirmed], 
    [SecurityStamp], 
    [TwoFactorEnabled]
) VALUES 
(
    'd4d48ac9-4591-42fb-b144-544894bf6d63', 
    'TEST', 
    'test@test.com', 
    'AQAAAAIAAYagAAAAEOXiZJUrEB06v0wOKZdEoUgeXaKt5botqvZopRUms4xe8krcmZ55UDt6UtLC9lXyLQ==', 
    0, 
    '8c60bd4e-1745-4239-b4cf-ca153529b11b', 
    0, 
    1, 
    NULL, 
    'TEST@TEST.COM', 
    'TEST', 
    '3254534', 
    0, 
    'MQDJPDGH76QZ47JWMIPNQ3XOPREOY55R', 
    0
),
(
    'd2bab0f8-90d2-4673-ba99-89829bbc4810', 
    'TEST1', 
    'test1@test.com', 
    'AQAAAAIAAYagAAAAEJXFsLkLmxZo4E8e5PzJUJmYFBQSwjm5Ht81XNPgm6bAh8HKNAH9/wZAe/2b+3Pvig==', 
    0, 
    'f9c43c96-5e63-4f08-94d6-003d7e62fb23', 
    0, 
    1, 
    NULL, 
    'TEST1@TEST.COM', 
    'TEST1', 
    '2345324562', 
    0, 
    'SLIMEHXJMWRK2OCDRPEGGUQE3CEHM4AM', 
    0
),
(
    '2290ca16-b6d2-4c47-bab3-cf77a87a1335', 
    'Somename', 
    'someemail@test.com', 
    'AQAAAAIAAYagAAAAEArjzkwn7nntWAyDmFIvNGL5h43hGwLzJHHUHM9kTuOpbkgC33aY+rAWNc6gGbxHmg==', 
    0, 
    'aa37c404-dca1-4346-bb64-905d6418d230', 
    0, 
    1, 
    NULL, 
    'SOMEEMAIL@TEST.COM', 
    'SOMENAME', 
    '12387094', 
    0, 
    '6ANSLPHWG5EBUJHDN5PYH6SKCRTMRRNV', 
    0
);

INSERT INTO [AspNetUserRoles] ([UserId], [RoleId])
VALUES 
('d4d48ac9-4591-42fb-b144-544894bf6d63', '888AEA1D-7CD4-49B2-86BF-4250BE068694'),
('d2bab0f8-90d2-4673-ba99-89829bbc4810', '888AEA1D-7CD4-49B2-86BF-4250BE068694'),
('2290ca16-b6d2-4c47-bab3-cf77a87a1335', '888AEA1D-7CD4-49B2-86BF-4250BE068694');


INSERT INTO [Companies] (Id, Name, Description, Phone, Location, CompanyRepresentativeId)
VALUES 
('27bd892b-80bd-4e31-8512-79af11f89b63', 'Endava', '', NULL, NULL, 'd4d48ac9-4591-42fb-b144-544894bf6d63'),
('ca46df5e-c298-4e1e-b217-c26a7c96202d', 'ISD', '', NULL, NULL, 'd2bab0f8-90d2-4673-ba99-89829bbc4810'),
('77186653-b8b3-4413-927f-2b799935e1b7', 'Amdaris', '', NULL, NULL, '2290ca16-b6d2-4c47-bab3-cf77a87a1335');