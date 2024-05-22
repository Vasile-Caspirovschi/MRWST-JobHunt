--INSERT INTO public."JobPosts" ("Id", "Title", "JobSalary", "CompanyId", "JobDescription", "PublishDate", "JobType", "Experience", "JobCategoryId")
--VALUES
--	(gen_random_uuid(), 'Administrative Assistant', 45000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Provide administrative support to various departments.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '47d977ac-00d2-49a7-b0d5-4c29aae67a05'),
--	(gen_random_uuid(), 'Project Coordinator', 52000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Coordinate and manage project tasks to ensure successful completion.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '3d5a04a0-b712-4acf-9b1e-36a1bd59b389'),
--	(gen_random_uuid(), 'Public Relations Specialist', 58000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Develop and implement public relations strategies to enhance brand reputation.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'ec1763be-aab3-469f-b0e5-f732dc40cd73'),
--	(gen_random_uuid(), 'Customer Service Representative', 48000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Provide support and assistance to customers over the phone or email.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'a032fcae-84a6-4d4a-bac4-088b788a5684'),
--	(gen_random_uuid(), 'Human Resources Assistant', 42000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Assist with HR tasks such as recruitment, onboarding, and payroll.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '2673d3ce-86e7-462c-853f-adb5ea770bd9'),
--	(gen_random_uuid(), 'Marketing Assistant', 50000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Support marketing activities and gain industry knowledge.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '8a4df1f0-0a32-477d-9ca1-43a38f6db2dd'),
--	(gen_random_uuid(), 'Software Developer', 60000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Develop and maintain software applications.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
--	(gen_random_uuid(), 'Graphic Designer', 55000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Create visual content for marketing and branding materials.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '42784449-c385-413f-9f16-7d513d433323'),
--	(gen_random_uuid(), 'Accounting Assistant', 40000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Assist with bookkeeping, accounts payable, and receivable.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '61dd4c73-e2b7-484e-9ae0-519e0f39fa05'),
--	(gen_random_uuid(), 'Civil Engineer', 65000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Design and oversee the construction of civil infrastructure projects.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '3d5a04a0-b712-4acf-9b1e-36a1bd59b389'),
--	(gen_random_uuid(), 'Social Media Coordinator', 48000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Manage social media presence and engage with followers.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'ec1763be-aab3-469f-b0e5-f732dc40cd73'),
--	(gen_random_uuid(), 'Sales Representative', 52000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Sell company products and services to generate revenue.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'a032fcae-84a6-4d4a-bac4-088b788a5684'),
--	(gen_random_uuid(), 'Teacher', 50000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Develop and deliver educational instruction to students.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '54aef70a-8c5a-4c0f-83a8-fa7a61249298'),
--	(gen_random_uuid(), 'Accountant', 55000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Manage financial records and prepare financial statements.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '61dd4c73-e2b7-484e-9ae0-519e0f39fa05'),
--	(gen_random_uuid(), 'Content Writer', 45000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Create engaging and informative content for various purposes.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '8a4df1f0-0a32-477d-9ca1-43a38f6db2dd'),
--	(gen_random_uuid(), 'Web Developer', 60000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Develop and maintain websites and web applications.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5');

--DECLARE @DefaultCategoryID uniqueidentifier = '058F1E09-8042-41D6-81CE-63BCD897C913'; -- Replace with a valid ID if needed
            
--            INSERT INTO [JobPosts] ([Id], [Title], [JobSalary], [CompanyId], [JobDescription], [PublishDate], [JobType], [Experience], [JobCategoryId])
--            SELECT NEWID(),
--                   Title,
--                   JobSalary,
--                   CompanyId,
--                   JobDescription,
--                    GETDATE(),
--                   JobType,
--                   Experience,
--                   ISNULL(JobCategoryId, @DefaultCategoryID)  -- Use default ID if JobCategoryId is null
--            FROM (
--                VALUES
--                ('Marketing Assistant', 50000, '77186653-B8B3-4413-927F-2B799935E1B7', 'Support marketing activities and gain industry knowledge.', 'FullTime', 'OneToTwoYears', '058F1E09-8042-41D6-81CE-63BCD897C913'),
--            	('Software Developer', 60000, '77186653-B8B3-4413-927F-2B799935E1B7', 'Develop and maintain software applications.', 'FullTime', 'OneToTwoYears', '058F1E09-8042-41D6-81CE-63BCD897C913'),
--            	('Graphic Designer', 55000, '77186653-B8B3-4413-927F-2B799935E1B7', 'Create visual content for marketing and branding materials.', 'FullTime', 'OneToTwoYears', '058F1E09-8042-41D6-81CE-63BCD897C913'),
--            	('Accounting Assistant', 40000, '27BD892B-80BD-4E31-8512-79AF11F89B63', 'Assist with bookkeeping, accounts payable, and receivable.', 'FullTime', 'OneToTwoYears', '058F1E09-8042-41D6-81CE-63BCD897C913'),
--            	('Civil Engineer', 65000, '27BD892B-80BD-4E31-8512-79AF11F89B63', 'Design and oversee the construction of civil infrastructure projects.', 'FullTime', 'OneToTwoYears', '4486076E-5095-4EF1-85A5-42EC9F706133'),
--            	('Social Media Coordinator', 48000, '27BD892B-80BD-4E31-8512-79AF11F89B63', 'Manage social media presence and engage with followers.', 'FullTime', 'OneToTwoYears', '4486076E-5095-4EF1-85A5-42EC9F706133'),
--            	('Sales Representative', 52000, '27BD892B-80BD-4E31-8512-79AF11F89B63', 'Sell company products and services to generate revenue.', 'FullTime', 'OneToTwoYears', 'D0BA5F0B-E93E-4EE1-BE07-46C8F1F1F0FA'),
--            	('Teacher', 50000, 'CA46DF5E-C298-4E1E-B217-C26A7C96202D', 'Develop and deliver educational instruction to students.', 'FullTime', 'OneToTwoYears', '145AFCEF-6E7A-4A81-A706-545697457B36'),
--            	('Accountant', 55000, 'CA46DF5E-C298-4E1E-B217-C26A7C96202D', 'Manage financial records and prepare financial statements.', 'FullTime', 'OneToTwoYears', '058F1E09-8042-41D6-81CE-63BCD897C913'),
--            	('Content Writer', 45000, 'CA46DF5E-C298-4E1E-B217-C26A7C96202D', 'Create engaging and informative content for various purposes.', 'FullTime', 'OneToTwoYears', '058F1E09-8042-41D6-81CE-63BCD897C913'),
--            	('Web Developer', 60000, 'CA46DF5E-C298-4E1E-B217-C26A7C96202D', 'Develop and maintain websites and web applications.', 'FullTime', 'OneToTwoYears', '058F1E09-8042-41D6-81CE-63BCD897C913')
--            ) AS NewJobPosts([Title], [JobSalary], [CompanyId], [JobDescription], [JobType], [Experience], [JobCategoryId]);

INSERT INTO [JobPosts] ([Id], [Title], [JobSalary], [CompanyId], [JobDescription], [PublishDate], [JobType], [Experience], [JobCategoryId])
VALUES
    (NEWID(), 'Administrative Assistant', 45000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Provide administrative support to various departments.', GETDATE(), 'FullTime', 'OneToTwoYears', 'E1CE6415-04F2-4497-97EC-03353FF187EE'),
    (NEWID(), 'Project Coordinator', 52000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Coordinate and manage project tasks to ensure successful completion.', GETDATE(), 'FullTime', 'OneToTwoYears', 'E1CE6415-04F2-4497-97EC-03353FF187EE'),
    (NEWID(), 'Public Relations Specialist', 58000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Develop and implement public relations strategies to enhance brand reputation.', GETDATE(), 'FullTime', 'OneToTwoYears', 'E1CE6415-04F2-4497-97EC-03353FF187EE'),
    (NEWID(), 'Customer Service Representative', 48000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Provide support and assistance to customers over the phone or email.', GETDATE(), 'FullTime', 'OneToTwoYears', 'E1CE6415-04F2-4497-97EC-03353FF187EE'),
    (NEWID(), 'Human Resources Assistant', 42000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Assist with HR tasks such as recruitment, onboarding, and payroll.', GETDATE(), 'FullTime', 'OneToTwoYears', 'E1CE6415-04F2-4497-97EC-03353FF187EE');
