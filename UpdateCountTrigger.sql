create trigger UpdateCount
on Users
after insert, update, delete
as
    declare @t table (newCount int, SchoolId int);
	insert into @t (newCount, SchoolId)
    select count(SchoolId), SchoolId
    from Users
    group by SchoolId;

	update Schools
	set Schools.Count = 
		(select newCount
		from @t as t
		where Schools.Id = t.SchoolId)
