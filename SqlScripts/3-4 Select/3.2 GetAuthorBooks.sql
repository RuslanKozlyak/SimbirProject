Select a.first_name,a.middle_name,a.last_name,b.name,g.genre_name
From Book as b
Join author as a
On b.author_id = a.id
join book_genre as bg
on bg.book_id = b.id
join genre as g
on g.id = bg.genre_id