Select p.first_name, lc.pickup_date,DATEDIFF(DAYOFYEAR,GETDATE(),lc.pickup_date) as 'Дней задержки', Count(lc.book_id) as 'Количество книг'
From person as p
Join library_card as lc
on lc.person_id = p.id
group by p.first_name, lc.pickup_date
