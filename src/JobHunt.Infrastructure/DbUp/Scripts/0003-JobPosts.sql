INSERT INTO public."JobPosts" ("Id", "Title", "JobSalary", "CompanyId", "JobDescription", "PublishDate", "JobType", "Experience", "JobCategoryId")
VALUES
	(gen_random_uuid(), 'Administrative Assistant', 45000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Provide administrative support to various departments.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '47d977ac-00d2-49a7-b0d5-4c29aae67a05'),
	(gen_random_uuid(), 'Project Coordinator', 52000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Coordinate and manage project tasks to ensure successful completion.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '3d5a04a0-b712-4acf-9b1e-36a1bd59b389'),
	(gen_random_uuid(), 'Public Relations Specialist', 58000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Develop and implement public relations strategies to enhance brand reputation.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'ec1763be-aab3-469f-b0e5-f732dc40cd73'),
	(gen_random_uuid(), 'Customer Service Representative', 48000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Provide support and assistance to customers over the phone or email.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'a032fcae-84a6-4d4a-bac4-088b788a5684'),
	(gen_random_uuid(), 'Human Resources Assistant', 42000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Assist with HR tasks such as recruitment, onboarding, and payroll.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '2673d3ce-86e7-462c-853f-adb5ea770bd9'),
	(gen_random_uuid(), 'Marketing Assistant', 50000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Support marketing activities and gain industry knowledge.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '8a4df1f0-0a32-477d-9ca1-43a38f6db2dd'),
	(gen_random_uuid(), 'Software Developer', 60000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Develop and maintain software applications.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	(gen_random_uuid(), 'Graphic Designer', 55000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Create visual content for marketing and branding materials.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '42784449-c385-413f-9f16-7d513d433323'),
	(gen_random_uuid(), 'Accounting Assistant', 40000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Assist with bookkeeping, accounts payable, and receivable.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '61dd4c73-e2b7-484e-9ae0-519e0f39fa05'),
	(gen_random_uuid(), 'Civil Engineer', 65000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Design and oversee the construction of civil infrastructure projects.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '3d5a04a0-b712-4acf-9b1e-36a1bd59b389'),
	(gen_random_uuid(), 'Social Media Coordinator', 48000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Manage social media presence and engage with followers.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'ec1763be-aab3-469f-b0e5-f732dc40cd73'),
	(gen_random_uuid(), 'Sales Representative', 52000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Sell company products and services to generate revenue.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'a032fcae-84a6-4d4a-bac4-088b788a5684'),
	(gen_random_uuid(), 'Teacher', 50000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Develop and deliver educational instruction to students.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '54aef70a-8c5a-4c0f-83a8-fa7a61249298'),
	(gen_random_uuid(), 'Accountant', 55000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Manage financial records and prepare financial statements.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '61dd4c73-e2b7-484e-9ae0-519e0f39fa05'),
	(gen_random_uuid(), 'Content Writer', 45000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Create engaging and informative content for various purposes.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', '8a4df1f0-0a32-477d-9ca1-43a38f6db2dd'),
	(gen_random_uuid(), 'Web Developer', 60000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Develop and maintain websites and web applications.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5');















	--(gen_random_uuid(), 'Software Engineer', 80000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Develop and maintain software applications.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Data Analyst', 75000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Analyze and interpret data to support business decisions.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Marketing Manager', 90000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Develop and execute marketing campaigns.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Web Developer', 70000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Develop and maintain websites and web applications.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Graphic Designer', 65000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Create visual content for marketing and branding.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Sales Representative', 60000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Sell company products and services to generate revenue.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Human Resources Specialist', 72000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Manage employee relations and recruitment processes.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Customer Service Representative', 55000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Provide support and assistance to customers.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Accountant', 68000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Manage financial records and prepare financial statements.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Project Manager', 85000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Lead and manage project teams to achieve project goals.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Business Analyst', 78000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Analyze business processes and identify improvement opportunities.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Software Developer', 80000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Develop and maintain software applications.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Quality Assurance Engineer', 72000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Test and ensure the quality of software products.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Network Administrator', 75000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Manage and maintain computer networks.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Content Writer', 60000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Create engaging and informative content for various purposes.', CURRENT_DATE,'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Social Media Manager', 65000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Manage social media presence and engage with followers.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Junior Software Engineer', 65000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Gain experience in software development under mentorship.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Marketing Assistant', 55000, '27bd892b-80bd-4e31-8512-79af11f89b63', 'Support marketing activities and gain industry knowledge.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Business Development Associate', 62000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Identify and develop new business opportunities.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'UX/UI Designer', 70000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Design user-friendly interfaces for software applications.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5'),
	--(gen_random_uuid(), 'Content Marketing Specialist', 60000, 'ca46df5e-c298-4e1e-b217-c26a7c96202d', 'Create and manage content to attract and engage customers.', CURRENT_DATE, 'FullTime', 'OneToTwoYears', 'd90f52af-0844-400c-8ae4-a2510b7e35a5');

