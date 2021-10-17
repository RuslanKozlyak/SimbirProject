Select p.first_name, lc.pickup_date,DATEDIFF(DAYOFYEAR,GETDATE(),lc.pickup_date) as 'Дней задержки'
From person as p
Join library_card as lc
on lc.person_id = p.id
where DATEDIFF(DAYOFYEAR,lc.pickup_date,GETDATE()) > 14
group by p.first_name, lc.pickup_date
having Count(lc.book_id)>3