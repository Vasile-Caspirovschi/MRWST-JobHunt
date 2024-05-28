--INSERT INTO public."AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp")
--VALUES
--	(gen_random_uuid(), 'Admin', 'ADMIN', gen_random_uuid()),
--	(gen_random_uuid(), 'Employer', 'EMPLOYER', gen_random_uuid()),
--	(gen_random_uuid(), 'JobSeeker', 'JOBSEEKER', gen_random_uuid());

INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
VALUES
    (NEWID(), 'Admin', 'ADMIN', NEWID()),
    (NEWID(), 'Employer', 'EMPLOYER', NEWID()),
    (NEWID(), 'JobSeeker', 'JOBSEEKER', NEWID());