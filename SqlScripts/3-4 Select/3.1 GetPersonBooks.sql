SELECT person.id, book.*
FROM person 
JOIN library_card AS lc 
ON lc.person_id = 1
JOIN book
ON book.id = lc.book_id;
