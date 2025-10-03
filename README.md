📚 Library Management System (LMS)
📖 Overview

The Library Management System (LMS) is designed to manage books, categories, authors, members, loans, and fines in an efficient and structured way.

It provides:

✅ A structured way to organize books by categories and authors

✅ Easy registration and tracking of members

✅ Automated borrowing and returning of books

✅ Fine calculation for overdue or damaged items

⚙️ System Behavior

Members can search books by title, author, or category

Borrowing assigns a due date (e.g., 14 days from loan date)

If returned on time → no fine

If overdue or damaged → system automatically calculates a fine

If fines remain unpaid → member is suspended


🚀 Steps I Took to Solve

Designed database schema (ER Diagram & Class Diagram)

Implemented EF Core models with configurations

Seeded database with sample data

Implemented borrowing & returning logic (with fines & suspension rules)

Added LINQ queries for data retrieval and reporting

Organized project with GitHub branching strategy (development = main, project = active work)
