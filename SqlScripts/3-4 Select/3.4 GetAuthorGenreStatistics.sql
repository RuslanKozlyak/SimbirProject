Select a.first_name,a.middle_name,a.last_name,b.name,g.genre_name,Count(g.genre_name)
From author as a
Join book as b
on b.author_id = a.id
Join book_genre as bg
on bg.book_id = b.id
Join genre as g
on g.id = bg.book_id
Group by a.first_name,a.middle_name,a.last_name,b.name,g.genre_name