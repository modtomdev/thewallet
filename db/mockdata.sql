INSERT INTO "users" ("id", "username", "password_hash", "salt", "cmc_apikey") VALUES
(1, 'user1', 'hashed_password_1', 'salt_1', 'api_key_1'),
(2, 'user2', 'hashed_password_2', 'salt_2', 'api_key_2');

INSERT INTO "categories" ("id", "name", "user_id", "is_expense") VALUES
(1, 'Food', 1, TRUE),
(2, 'Salary', 1, FALSE),
(3, 'Rent', 2, TRUE);

INSERT INTO "accounts" ("id", "user_id", "name") VALUES
(1, 1, 'Personal Account'),
(2, 1, 'Savings Account'),
(3, 2, 'Business Account');

INSERT INTO "assets" ("id", "symbol", "name", "current_value_eur") VALUES
(1, 'BTC', 'Bitcoin', 30000.00),
(2, 'ETH', 'Ethereum', 2000.00),
(3, 'AAPL', 'Apple', 150.00),
(4, 'EUR', 'Euro', 1.00),
(5, 'JPY', 'Yen', 0.0075);

INSERT INTO "asset_holdings" ("id", "account_id", "asset_id", "quantity", "purchase_date", "purchase_price") VALUES
(1, 1, 1, 0.5, '2024-01-15', 20000.00),
(2, 1, 2, 10, '2024-01-20', 1500.00),
(3, 2, 1, 1, '2024-02-10', 25000.00),
(4, 2, 3, 50, '2024-02-25', 130.00);

INSERT INTO "transfers" ("id", "fromaccount_id", "toaccount_id", "asset_id", "amount") VALUES
(1, 1, 2, 1, 0.1),
(2, 2, 1, 2, 5);

INSERT INTO "transactions" ("id", "account_id", "category_id", "asset_id", "amount", "description") VALUES
(1, 1, 1, 1, 1000.00, 'Purchase of groceries'),
(2, 1, 2, 2, 1500.00, 'Received salary'),
(3, 2, 3, 3, 800.00, 'Rent payment');

INSERT INTO "recurring_transactions" ("id", "type", "desired_date", "asset_holding_id", "quantity") VALUES
(1, 'daily', '2024-03-30', 1, 0.1),
(2, 'weekly', '2024-04-01', 2, 5),
(3, 'monthly', '2024-05-01', 3, 10),
(4, 'yearly', '2025-01-01', 4, 1000),
(5, 'monthly', '2024-04-01', 5, 10000);


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

