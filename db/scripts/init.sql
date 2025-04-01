CREATE TABLE IF NOT EXISTS "users"(
    "id" SERIAL PRIMARY KEY,
    "username" VARCHAR(64) UNIQUE NOT NULL,
    "password_hash" VARCHAR(128) NOT NULL,
    "salt" VARCHAR(128) NOT NULL,
    "cmc_apikey" VARCHAR(64),
    "created_at" TIMESTAMP DEFAULT NOW() NOT NULL
);

CREATE TABLE IF NOT EXISTS "categories"(
    "id" SERIAL PRIMARY KEY,
    "name" VARCHAR(64) UNIQUE NOT NULL,
    "user_id" INT NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    "is_expense" BOOLEAN NOT NULL,
    "created_at" TIMESTAMP DEFAULT NOW() NOT NULL
);

CREATE TABLE IF NOT EXISTS "accounts"(
    "id" SERIAL PRIMARY KEY,
    "user_id" INT NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    "name" VARCHAR(64) NOT NULL,
    "created_at" TIMESTAMP DEFAULT NOW() NOT NULL
);

CREATE TABLE IF NOT EXISTS "assets"(
    "id" SERIAL PRIMARY KEY,
    "symbol" VARCHAR(64) NOT NULL,
    "name" VARCHAR(64) UNIQUE NOT NULL,
    "current_value_eur" DECIMAL(18,8) DEFAULT 0 CHECK (current_value_eur >= 0),
    "value_timestamp" TIMESTAMP DEFAULT NOW() NOT NULL
);

CREATE TABLE IF NOT EXISTS "asset_holdings"(
    "id" SERIAL PRIMARY KEY,
    "account_id" INT NOT NULL REFERENCES accounts(id) ON DELETE CASCADE,
    "asset_id" INTEGER NOT NULL REFERENCES assets(id) ON DELETE CASCADE,
    "quantity" DECIMAL(18,8) NOT NULL CHECK (quantity >= 0),
    "purchase_date" TIMESTAMP(0) NOT NULL
);

CREATE TABLE IF NOT EXISTS "transfers"(
    "id" SERIAL PRIMARY KEY,
    "fromaccount_id" INT NOT NULL REFERENCES accounts(id) ON DELETE CASCADE,
    "toaccount_id" INT NOT NULL REFERENCES accounts(id) ON DELETE CASCADE,
    "asset_id" INT NOT NULL REFERENCES assets(id) ON DELETE CASCADE,
    "amount" DECIMAL(18,8) NOT NULL,
    "created_at" TIMESTAMP DEFAULT NOW() NOT NULL,
    CHECK (fromaccount_id <> toaccount_id)
);

CREATE TABLE IF NOT EXISTS "transactions"(
    "id" SERIAL PRIMARY KEY,
    "account_id" INT NOT NULL REFERENCES accounts(id) ON DELETE CASCADE,
    "category_id" INT NOT NULL REFERENCES categories(id) ON DELETE CASCADE,
    "asset_id" INT NOT NULL REFERENCES assets(id) ON DELETE CASCADE,
    "amount" DECIMAL(18,8) NOT NULL,
    "description" VARCHAR(255),
    "created_at" TIMESTAMP DEFAULT NOW() NOT NULL
    CHECK (amount >= 0)
);

CREATE TABLE IF NOT EXISTS "graph_snapshots"(
    "id" SERIAL PRIMARY KEY,
    "account_id" INT NOT NULL REFERENCES accounts(id) ON DELETE CASCADE,
    "graph_time" TIMESTAMP DEFAULT NOW() NOT NULL,
    "account_value_eur" DECIMAL(18,8) NOT NULL
);

CREATE TABLE IF NOT EXISTS "recurring_transactions"(
    "id" SERIAL PRIMARY KEY,
    "type" VARCHAR(64) CHECK ("type" IN ('daily', 'weekly', 'monthly', 'yearly')) NOT NULL,
    "desired_date" DATE NOT NULL,
    "created_at" TIMESTAMP DEFAULT NOW() NOT NULL,
    "asset_holding_id" INT NOT NULL REFERENCES asset_holdings(id) ON DELETE CASCADE,
    "quantity" DECIMAL(18,8) NOT NULL
);

INSERT INTO assets(symbol, name, current_value_eur) VALUES
('EUR', 'Euro', 1);

INSERT INTO assets(symbol, name) VALUES
('EURJPY=X', 'Yen'),
('XEON.MI','Xtrackers II EUR Overnight Rate Swap UCITS ETF 1C'),
('ETH', 'Ethereum'),
('ADA', 'Cardano'),
('DOT', 'Polkadot'),
('SUI', 'Sui'),
('PI', 'Pi');

INSERT INTO "users" ("username", "password_hash", "salt", "cmc_apikey") VALUES
('user1', 'hashed_password_1', 'salt_1', 'api_key_1'),
('user2', 'hashed_password_2', 'salt_2', 'api_key_2');

INSERT INTO "categories" ("name", "user_id", "is_expense") VALUES
('Food', 1, TRUE),
('Salary', 1, FALSE),
('Rent', 2, TRUE);

INSERT INTO "accounts" ("user_id", "name") VALUES
(1, 'Personal Account'),
(1, 'Savings Account'),
(2, 'Business Account');

INSERT INTO "asset_holdings" ("account_id", "asset_id", "quantity", "purchase_date") VALUES
(1, 1, 0.5, '2024-01-15'),
(1, 2, 10, '2024-01-20'),
(2, 1, 1, '2024-02-10'),
(2, 3, 50, '2024-02-25');

INSERT INTO "transfers" ("fromaccount_id", "toaccount_id", "asset_id", "amount") VALUES
(1, 2, 1, 0.1),
(2, 1, 2, 5);

INSERT INTO "transactions" ("account_id", "category_id", "asset_id", "amount", "description") VALUES
(1, 1, 1, 1000.00, 'Purchase of groceries'),
(1, 2, 2, 1500.00, 'Received salary'),
(2, 3, 3, 800.00, 'Rent payment');

INSERT INTO "recurring_transactions" ("type", "desired_date", "asset_holding_id", "quantity") VALUES
('daily', '2024-03-30', 1, 0.1),
('weekly', '2024-04-01', 2, 5),
('monthly', '2024-05-01', 3, 10),
('yearly', '2025-01-01', 4, 1000);


DO $$ 
DECLARE 
    i INT;
    account_val DECIMAL := 35000.00;
BEGIN 
    FOR i IN 1..31 LOOP 
        INSERT INTO "graph_snapshots" ("account_id", "graph_time", "account_value_eur")
        VALUES (1, ('2025-03-' || LPAD(i::TEXT, 2, '0') || ' 10:00:00')::TIMESTAMP, account_val);
        account_val := account_val + (RANDOM() * 200 - 100); 
    END LOOP;
END $$;



