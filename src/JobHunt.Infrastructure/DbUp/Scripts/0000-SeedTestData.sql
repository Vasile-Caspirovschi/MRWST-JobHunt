--Seeding Roles
INSERT INTO [jobhunt-db].dbo.AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES (N'37DD3969-EBA5-4EC0-B953-39D6DD337CE3', N'Admin', N'ADMIN', N'C64B6626-6F3E-4BD4-9390-ECC303130735');
INSERT INTO [jobhunt-db].dbo.AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES (N'4FE50A6E-100C-48AF-9C92-D87C87E008D5', N'JobSeeker', N'JOBSEEKER', N'6A3C3B14-73F4-4AA6-BC7C-7EFCEE0BF8F9');
INSERT INTO [jobhunt-db].dbo.AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES (N'EFC0D848-F5F1-4FB6-802C-F948F3AA4C09', N'Employer', N'EMPLOYER', N'974627EF-4917-4050-8BCA-7EA7B117B6FF');

--Seeding Users
INSERT INTO [jobhunt-db].dbo.Users (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'929AE98E-CB96-4A42-8602-08DC7BE63716', N'StefaniniHR', N'STEFANINIHR', N'stefanini@test.com', N'STEFANINI@TEST.COM', 0, N'AQAAAAIAAYagAAAAEPDUpcBZwdUSeXIZztZ71+mYTrDXfQHxIqq0lQxE3FpWQi8SMZPrvLGuQeBhHi1X+A==', N'NGERUPHIPWWK6ZEBROTXDW6CDTNZBDZE', N'829354e0-0cfb-4dc1-ae58-0caeb216ba64', N'534253423542', 0, 0, null, 1, 0);
INSERT INTO [jobhunt-db].dbo.Users (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'97FA7E3B-4416-463B-1F28-08DC7C9AC9CF', N'EndavaHR', N'ENDAVAHR', N'endava@test.com', N'ENDAVA@TEST.COM', 0, N'AQAAAAIAAYagAAAAEOQR2tAbGVwrVrzA7Y6Qxen0beqRHrsyRsP+PhQetwn418IipWtmaqVxh1SttsO1hg==', N'GEFBBQ32KUMG6PFSTW6KIHITTVQVTOXU', N'0844d874-cd06-4a70-9065-ed50dafd79f8', N'12348790213', 0, 0, null, 1, 0);
INSERT INTO [jobhunt-db].dbo.Users (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'EF9CFD93-19D8-40FC-A8EE-08DC7CAFC5E3', N'Vasile', N'VASILE', N'vasile@test.com', N'VASILE@TEST.COM', 0, N'AQAAAAIAAYagAAAAEOdyp6Fidw8EIOZn0D88u7FEmF83yI/hS4WpKGzZsKbNTNklrM7T4UCUzPX9OiGd6Q==', N'C5NU233SZ74YDHHNNFTGUJDUZN3UUNVT', N'2b267cba-8494-4d4b-ae79-387f205b54fb', N'1234879023', 0, 0, null, 1, 0);
INSERT INTO [jobhunt-db].dbo.Users (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'D2BAB0F8-90D2-4673-BA99-89829BBC4810', N'ISDHR', N'ISDHR', N'isd@test.com', N'ISD@TEST.COM', 0, N'AQAAAAIAAYagAAAAEJXFsLkLmxZo4E8e5PzJUJmYFBQSwjm5Ht81XNPgm6bAh8HKNAH9/wZAe/2b+3Pvig==', N'SLIMEHXJMWRK2OCDRPEGGUQE3CEHM4AM', N'f9c43c96-5e63-4f08-94d6-003d7e62fb23', N'2345324562', 0, 0, null, 1, 0);
INSERT INTO [jobhunt-db].dbo.Users (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'2290CA16-B6D2-4C47-BAB3-CF77A87A1335', N'AmdarisHR', N'AMDARISHR', N'amdaris@test.com', N'AMDARIS@TEST.COM', 0, N'AQAAAAIAAYagAAAAEArjzkwn7nntWAyDmFIvNGL5h43hGwLzJHHUHM9kTuOpbkgC33aY+rAWNc6gGbxHmg==', N'6ANSLPHWG5EBUJHDN5PYH6SKCRTMRRNV', N'76b8f1eb-5aed-4488-b177-cdf947199e33', N'12387094', 0, 0, null, 1, 0);

--Seeding UserRoles
INSERT INTO [jobhunt-db].dbo.AspNetUserRoles (UserId, RoleId) VALUES (N'EF9CFD93-19D8-40FC-A8EE-08DC7CAFC5E3', N'4FE50A6E-100C-48AF-9C92-D87C87E008D5');
INSERT INTO [jobhunt-db].dbo.AspNetUserRoles (UserId, RoleId) VALUES (N'929AE98E-CB96-4A42-8602-08DC7BE63716', N'EFC0D848-F5F1-4FB6-802C-F948F3AA4C09');
INSERT INTO [jobhunt-db].dbo.AspNetUserRoles (UserId, RoleId) VALUES (N'97FA7E3B-4416-463B-1F28-08DC7C9AC9CF', N'EFC0D848-F5F1-4FB6-802C-F948F3AA4C09');
INSERT INTO [jobhunt-db].dbo.AspNetUserRoles (UserId, RoleId) VALUES (N'D2BAB0F8-90D2-4673-BA99-89829BBC4810', N'EFC0D848-F5F1-4FB6-802C-F948F3AA4C09');
INSERT INTO [jobhunt-db].dbo.AspNetUserRoles (UserId, RoleId) VALUES (N'2290CA16-B6D2-4C47-BAB3-CF77A87A1335', N'EFC0D848-F5F1-4FB6-802C-F948F3AA4C09');

--Seeding JobSeekers
INSERT INTO [jobhunt-db].dbo.JobSeekers (Id, CVId) VALUES (N'EF9CFD93-19D8-40FC-A8EE-08DC7CAFC5E3', N'D9050D10-0F5A-470C-0692-08DC7E5862A6');

--Seeding CV
INSERT INTO [jobhunt-db].dbo.CVs (Id, FileUrl, PublicId, FileName) VALUES (N'D9050D10-0F5A-470C-0692-08DC7E5862A6', N'https://res.cloudinary.com/dfeuzsgam/image/upload/v1716819725/wmhfqx4nmbxnile8bzh9.pdf', N'wmhfqx4nmbxnile8bzh9', N'Caspirovschi_Vasile_CV.pdf');

--Seeding Employers
INSERT INTO [jobhunt-db].dbo.Employers (Id, CompanyId) VALUES (N'929AE98E-CB96-4A42-8602-08DC7BE63716', N'7C3BB605-BA0B-4ABA-DEF0-08DC7BE63C84');
INSERT INTO [jobhunt-db].dbo.Employers (Id, CompanyId) VALUES (N'97FA7E3B-4416-463B-1F28-08DC7C9AC9CF', N'27BD892B-80BD-4E31-8512-79AF11F89B63');
INSERT INTO [jobhunt-db].dbo.Employers (Id, CompanyId) VALUES (N'D2BAB0F8-90D2-4673-BA99-89829BBC4810', N'CA46DF5E-C298-4E1E-B217-C26A7C96202D');
INSERT INTO [jobhunt-db].dbo.Employers (Id, CompanyId) VALUES (N'2290CA16-B6D2-4C47-BAB3-CF77A87A1335', N'77186653-B8B3-4413-927F-2B799935E1B7');

--Seeding Companies
INSERT INTO [jobhunt-db].dbo.Companies (Id, Name, Description, Phone, EmployerId, Location) VALUES (N'7C3BB605-BA0B-4ABA-DEF0-08DC7BE63C84', N'Stefanini', N'', null, N'929AE98E-CB96-4A42-8602-08DC7BE63716', null);
INSERT INTO [jobhunt-db].dbo.Companies (Id, Name, Description, Phone, EmployerId, Location) VALUES (N'77186653-B8B3-4413-927F-2B799935E1B7', N'Amdaris', N'', null, N'2290CA16-B6D2-4C47-BAB3-CF77A87A1335', null);
INSERT INTO [jobhunt-db].dbo.Companies (Id, Name, Description, Phone, EmployerId, Location) VALUES (N'27BD892B-80BD-4E31-8512-79AF11F89B63', N'Endava', N'Combining world-class engineering, industry expertise and a people-centric mindset, we consult and partner with our customers to create technological solutions that drive innovation and transform businesses.
With 20+ years of experience, we’ve supported technology modernisation and industry growth around the world. Explore our work to learn how we can help you create a success story of your own.', N'022806700', N'97FA7E3B-4416-463B-1F28-08DC7C9AC9CF', N'Strada Arborilor 21a,, Chișinău');
INSERT INTO [jobhunt-db].dbo.Companies (Id, Name, Description, Phone, EmployerId, Location) VALUES (N'CA46DF5E-C298-4E1E-B217-C26A7C96202D', N'ISD', N'ISD is a software development company. We offer super-fast response time, excellent communication, and flexibility. Work with us as if we sit in your office with daily check-ins, desk time reports & site visits. We handle every project with passion and dedication. Let’s discuss how we can team up!', N'022996170', N'D2BAB0F8-90D2-4673-BA99-89829BBC4810', N'Strada Bulgară, Chișinău');

--Seeding Companies Images
INSERT INTO [jobhunt-db].dbo.Images (Id, ImageUrl, PublicId, CompanyId) VALUES (N'B1252202-CB99-448A-B3DC-08DC7BFDE027', N'https://res.cloudinary.com/dfeuzsgam/image/upload/v1716560948/xhtfua7fyxlrqyblp4zw.png', N'xhtfua7fyxlrqyblp4zw', N'CA46DF5E-C298-4E1E-B217-C26A7C96202D');
INSERT INTO [jobhunt-db].dbo.Images (Id, ImageUrl, PublicId, CompanyId) VALUES (N'B76BC2AD-0D1C-4767-0003-08DC7C9C86C1', N'https://res.cloudinary.com/dfeuzsgam/image/upload/v1716629088/tescg3stkrpea55wtmse.png', N'tescg3stkrpea55wtmse', N'27BD892B-80BD-4E31-8512-79AF11F89B63');

--Seeding JobCategories
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'CD597040-3CF3-44F9-AE2C-02D6FEB286EB', N'Human Resources & Recruitment');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'3CC52EC2-D720-4050-BDA0-12334091E9F7', N'Psychology');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'8C1C7759-F6FC-413C-BB88-24D70FE0B504', N'Domestic Staff');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'D6300D37-A26F-43EC-BB7F-324F1F8B49B9', N'Administration & Business Support');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'322B1508-57AA-4C53-8392-411EE001DDBA', N'Education & Training');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'22580798-0AD4-49BA-A1A0-5331C3D1F84B', N'Mass Media, Journalism');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'931079AD-0B23-44BB-9401-559FC93C29F1', N'Telecommunication Network');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'10CDC3AD-C10F-4970-B5A7-70C11D03C865', N'Finance & Accounting');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'9091A610-378F-4277-9C01-76B3B3EAF3D5', N'Retail & Wholesale Trade');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'641A431D-E487-468D-BA5C-77802F101860', N'Transportation & Logistics');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'ED9B30F1-EA06-45D8-914B-78F7F27867DC', N'Healthcare');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'B856E87A-E339-4DDC-BD81-7E9206FAA605', N'Manufacturing & Production');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'4A89DCF1-BAB1-413E-9EA2-A384F7CEC3B8', N'Farms');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'048C6089-1892-47C7-8EC0-A9491F8EC092', N'Arts, Media & Communications');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'73BB675D-8B38-45D9-8F4E-B106B1D1DC4B', N'Foreign Languages, Translators');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'E4D2DFAB-E1FF-4499-B367-B63C208F0EF4', N'Insurance');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'748DA14D-7A02-408E-A3F3-C7523028FBA0', N'Telephone Operators, Call Centers');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'066AAB77-767F-4830-8A4C-CABC319B77AA', N'Architecture & Engineering');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'1266C1F5-EDC3-469C-8010-CD58543AA90E', N'Security & Law Enforcement');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'087FEDC0-5964-47AA-BF87-D036F3F4BF7D', N'Construction, Repair & Warehouse');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'DA938960-EFC6-44DE-B638-D0AFEEB1D860', N'Courses, Trainings');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'93CCE4AA-1712-47BD-AAC8-D71ECEADC636', N'Government & Public Administration');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'F31DE3D9-FDE8-4A43-8CED-D9464989B667', N'Procurement');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'4F42E5F8-2691-4586-AE66-DE4A67529395', N'Non-Profit & Social Services');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'D37005ED-9D82-476D-A0B7-DE5A59A63FEB', N'Beauty, Fitness, Sport');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'E59A1279-2E96-4673-A5FC-E31AF17F2005', N'Skilled Trades & Services');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'9DB02F2E-2ECF-4759-A962-E4F451DA8150', N'Legal');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'CDCB9D51-DD56-44CA-A670-E9509F820308', N'Marketing & Public Relations');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'3C5CD000-D33B-4AAE-B069-E97D24C019A7', N'Customer Service & Sales');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'1E396969-6156-4ACE-8179-ED253481DA3F', N'IT, Programming');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'98CDE08E-0EF5-472C-BC0A-EDBF5CC4B608', N'Design');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'6FCD5EC4-201B-48EE-ADBF-EE138A6998C9', N'Science & Research');
INSERT INTO [jobhunt-db].dbo.JobCategories (Id, Title) VALUES (N'65363F07-4DA5-4353-9540-F89DE49AFA1E', N'Service Industry');

--Seeding JobPosts
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'29D4C3E1-A7FC-4561-F94E-08DC7B3FDB5C', N'Junior .NET Developer', 1000, N'1E396969-6156-4ACE-8179-ED253481DA3F', N'CA46DF5E-C298-4E1E-B217-C26A7C96202D', N'<div class="inbody py-3 px-3 sm:px-6">
<h1 style="text-align: center;">Junior .NET Developer</h1>
<p>This project is one of the products of our Dutch partners, which has successfully operated for over three years and has been implemented in more than 100 customer projects. Its primary objective is to streamline logistics project operations into a unified system, fostering synergies that contribute to an overall reduction in project costs. The initiative also aims to establish a common domain language for seamless communication among departments, enhancing transparency and overall effectiveness.</p>
<p><strong>Who are you?</strong></p>
<ul>
<li>Enjoy writing efficient and testable code using .NET programming languages;</li>
<li>Ensure the ongoing functionality and improvement of current solutions;</li>
<li>Test and debug various .NET applications, review and refactor code;</li>
<li>Deploy functional applications.</li>
</ul>
<p><strong>What do we expect from you?</strong></p>
<ul>
<li>Upper-Intermediate in English;</li>
<li>Knowledge of .NET/C# (.NET Core), RESTful APIs, EF, MVC and Web Services;</li>
<li>Experience in the practice of Agile methodologies (Scrum) would be an advantage;</li>
<li>Expertise in utilizing PostgreSQL and Docker instruments would be beneficial;</li>
<li>Good communication and collaboration skills.</li>
</ul>
<p><strong>What is it in for you?</strong></p>
<ul>
<li>Private health insurance;</li>
<li>Sports compensation for gym memberships, online sports subscriptions;</li>
<li>Flexible schedule;</li>
<li>Education budget for Certifications, Courses, Training and Conferences (a part of the education budget can be spent on gadgets, that stay yours);</li>
<li>Books budget;</li>
<li>5 pm Club &ndash; a concept developed by ISD to offer 1-hour every week for self-development, development of your ideas and/or presentations to the team to improve public speaking skills.</li>
</ul>
<p><strong>If you are interested in, you can send your CV to <a href="mailto:talent@inthergroup.com">talent@inthergroup.com</a>.</strong></p>
</div>', N'2024-05-23', N'FullTime', N'ZeroToOneYears');
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'F6358B2A-841B-42DD-8BB8-195DAD7EEE0F', N'Content Writer', 45000, N'1E396969-6156-4ACE-8179-ED253481DA3F', N'CA46DF5E-C298-4E1E-B217-C26A7C96202D', N'Create engaging and informative content for various purposes.', N'2024-05-23', N'Remote', N'OneToTwoYears');
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'98A25525-0534-49D3-9A3E-1F1207E2E308', N'Accountant', 55000, N'10CDC3AD-C10F-4970-B5A7-70C11D03C865', N'CA46DF5E-C298-4E1E-B217-C26A7C96202D', N'Manage financial records and prepare financial statements.', N'2024-05-23', N'Remote', N'OneToTwoYears');
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'365A74D5-E1E8-4DD8-8445-21EFC80E222A', N'Civil Engineer', 65000, N'93CCE4AA-1712-47BD-AAC8-D71ECEADC636', N'27BD892B-80BD-4E31-8512-79AF11F89B63', N'Design and oversee the construction of civil infrastructure projects.', N'2024-05-23', N'FullTime', N'OneToTwoYears');
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'B6994C41-D53D-443A-80D0-517642268A3C', N'Social Media Coordinator', 48000, N'E59A1279-2E96-4673-A5FC-E31AF17F2005', N'27BD892B-80BD-4E31-8512-79AF11F89B63', N'Manage social media presence and engage with followers.', N'2024-05-23', N'FullTime', N'OneToTwoYears');
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'80135122-9E0D-40A5-A048-5A0E064E4516', N'Software Developer', 60000, N'1E396969-6156-4ACE-8179-ED253481DA3F', N'77186653-B8B3-4413-927F-2B799935E1B7', N'Develop and maintain software applications.', N'2024-05-23', N'PartTime', N'OneToTwoYears');
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'BFF8BBDC-A1A6-4CDC-9D95-645541B5B7F0', N'Graphic Designer', 55000, N'98CDE08E-0EF5-472C-BC0A-EDBF5CC4B608', N'77186653-B8B3-4413-927F-2B799935E1B7', N'Create visual content for marketing and branding materials.', N'2024-05-23', N'PartTime', N'OneToTwoYears');
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'49A0D992-18EE-4B29-AB7B-8C97B1930FC8', N'Web Developer', 60000, N'1E396969-6156-4ACE-8179-ED253481DA3F', N'CA46DF5E-C298-4E1E-B217-C26A7C96202D', N'Develop and maintain websites and web applications.', N'2024-05-23', N'FullTime', N'OneToTwoYears');
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'EC5712E0-C4BB-46EC-8442-9A6AE1C286F5', N'Teacher', 50000, N'322B1508-57AA-4C53-8392-411EE001DDBA', N'CA46DF5E-C298-4E1E-B217-C26A7C96202D', N'Develop and deliver educational instruction to students.', N'2024-05-23', N'Remote', N'OneToTwoYears');
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'028D70E0-1124-4C80-B0FC-B7905C4879C5', N'Marketing Assistant', 50000, N'1E396969-6156-4ACE-8179-ED253481DA3F', N'77186653-B8B3-4413-927F-2B799935E1B7', N'Support marketing activities and gain industry knowledge.', N'2024-05-23', N'PartTime', N'OneToTwoYears');
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'18A3DEBA-3A69-48C4-AB3E-D288D496996A', N'Accounting Assistant', 40000, N'10CDC3AD-C10F-4970-B5A7-70C11D03C865', N'27BD892B-80BD-4E31-8512-79AF11F89B63', N'Assist with bookkeeping, accounts payable, and receivable.', N'2024-05-23', N'FullTime', N'OneToTwoYears');
INSERT INTO [jobhunt-db].dbo.JobPosts (Id, Title, JobSalary, JobCategoryId, CompanyId, JobDescription, PublishDate, JobType, Experience) VALUES (N'BBB7C873-EFD9-423A-845E-D7D28E30A14B', N'Sales Representative', 52000, N'E59A1279-2E96-4673-A5FC-E31AF17F2005', N'27BD892B-80BD-4E31-8512-79AF11F89B63', N'Sell company products and services to generate revenue.', N'2024-05-23', N'Remote', N'OneToTwoYears');

--Seeding JobApplications
INSERT INTO [jobhunt-db].dbo.JobApplications (Id, ApplicantId, JobPostId, CompanyId, ApplicationDate, ApplicantEmail, ApplicantFullname) VALUES (N'575B2BD7-CF87-4F02-BA2B-08DC7E6586A9', N'EF9CFD93-19D8-40FC-A8EE-08DC7CAFC5E3', N'29D4C3E1-A7FC-4561-F94E-08DC7B3FDB5C', N'CA46DF5E-C298-4E1E-B217-C26A7C96202D', N'2024-05-27', N'vasile@test.com', N'Vasile');
INSERT INTO [jobhunt-db].dbo.JobApplications (Id, ApplicantId, JobPostId, CompanyId, ApplicationDate, ApplicantEmail, ApplicantFullname) VALUES (N'2A462891-CC81-4E3C-0474-08DC7F2FBB9C', N'EF9CFD93-19D8-40FC-A8EE-08DC7CAFC5E3', N'80135122-9E0D-40A5-A048-5A0E064E4516', N'77186653-B8B3-4413-927F-2B799935E1B7', N'2024-05-28', N'vasile@test.com', N'Vasile');
INSERT INTO [jobhunt-db].dbo.JobApplications (Id, ApplicantId, JobPostId, CompanyId, ApplicationDate, ApplicantEmail, ApplicantFullname) VALUES (N'E4B365C9-35F7-4AFA-9B0E-08DC7F587F1F', N'EF9CFD93-19D8-40FC-A8EE-08DC7CAFC5E3', N'49A0D992-18EE-4B29-AB7B-8C97B1930FC8', N'CA46DF5E-C298-4E1E-B217-C26A7C96202D', N'2024-05-28', N'vasile@test.com', N'Vasile');
