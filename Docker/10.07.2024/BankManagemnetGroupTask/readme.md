 Use Case: Banking System

 1. **Transactions**
   - **Description**: Handling of deposits, withdrawals, and transfers.
   - **Actors**: Customers, Bank Employees, ATM
   - **Components**:
     - **Deposit**: A customer can deposit money into their account.
     - **Withdrawal**: A customer can withdraw money from their account.
     - **Transfer**: A customer can transfer money between accounts.
   - **Process**:
     1. Customer initiates a transaction (deposit, withdrawal, or transfer).
     2. System validates the transaction (e.g., sufficient funds, correct account details).
     3. Transaction is processed and recorded in the customer's account.
     4. Confirmation is provided to the customer.

 2. **Loans**
   - **Description**: Management of different types of loans (personal, home, car, etc.).
   - **Actors**: Customers, Loan Officers
   - **Components**:
     - **Loan Application**: Customers apply for a loan.
     - **Loan Approval**: The bank reviews and approves/rejects the loan application.
     - **Loan Disbursement**: Approved loans are disbursed to the customer’s account.
     - **Repayment**: Customers repay the loan in installments.
   - **Process**:
     1. Customer applies for a loan.
     2. Loan officer reviews the application and customer’s creditworthiness.
     3. Loan is approved or rejected.
     4. Approved loan is disbursed.
     5. Customer repays the loan in scheduled installments.

 3. **Fixed Deposits (FD)**
   - **Description**: A fixed amount is deposited for a fixed term with a guaranteed interest rate.
   - **Actors**: Customers, Bank Employees
   - **Components**:
     - **FD Account Opening**: Customer opens an FD account.
     - **Interest Calculation**: Interest is calculated periodically.
     - **Maturity**: On maturity, the principal and interest are returned to the customer.
   - **Process**:
     1. Customer decides on the amount and term for the FD.
     2. Customer opens an FD account with the bank.
     3. Interest is calculated and added to the principal at regular intervals.
     4. On maturity, the total amount (principal + interest) is returned to the customer.

 4. **Recurring Deposits (RD)**
   - **Description**: A customer deposits a fixed amount at regular intervals and earns interest.
   - **Actors**: Customers, Bank Employees
   - **Components**:
     - **RD Account Opening**: Customer opens an RD account.
     - **Monthly Deposit**: Customer deposits a fixed amount monthly.
     - **Interest Calculation**: Interest is calculated periodically.
     - **Maturity**: On maturity, the total amount (deposits + interest) is returned to the customer.
   - **Process**:
     1. Customer decides on the monthly deposit amount and term for the RD.
     2. Customer opens an RD account with the bank.
     3. Customer makes regular monthly deposits.
     4. Interest is calculated and added to the deposited amount periodically.
     5. On maturity, the total amount (deposits + interest) is returned to the customer.

 Sequence Diagrams

Simplified sequence diagrams for each use case:

Transactions

Customer -> Bank System: Initiate Transaction
Bank System -> Bank System: Validate Transaction
Bank System -> Customer: Confirm Transaction


Loans

Customer -> Bank System: Apply for Loan
Bank System -> Loan Officer: Review Application
Loan Officer -> Bank System: Approve/Reject Loan
Bank System -> Customer: Notify Approval/Rejection
Bank System -> Customer: Disburse Loan (if approved)
Customer -> Bank System: Repay Loan in Installments


Fixed Deposits (FD)

Customer -> Bank System: Open FD Account
Bank System -> Customer: Confirm Account Opening
Bank System -> Bank System: Calculate Interest Periodically
Bank System -> Customer: Return Principal + Interest on Maturity


Recurring Deposits (RD)

Customer -> Bank System: Open RD Account
Bank System -> Customer: Confirm Account Opening
Customer -> Bank System: Monthly Deposit
Bank System -> Bank System: Calculate Interest Periodically
Bank System -> Customer: Return Deposits + Interest on Maturity

