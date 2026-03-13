CREATE TABLE IF NOT EXISTS strat (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    videourl TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS operator (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    side TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS categories (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    side TEXT NOT NULL,
    map TEXT NOT NULL,
    operator_id INT NOT NULL,
    FOREIGN KEY (operator_id) REFERENCES operator(id)
);

CREATE TABLE IF NOT EXISTS strat_categories (
    strat_id INT,
    category_id INT,
    PRIMARY KEY (strat_id, category_id)
);