Select g.genre_name, COUNT(bg.book_id)
From genre as g
Join book_genre as bg
On bg.genre_id = g.id
Group By g.genre_name