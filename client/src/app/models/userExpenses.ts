export type UserExpenses = {
    user: string;
    months: ExpenseMonth[];
};

export type ExpenseMonth = {
    monthStart: Date;
    income: Expense[];
    outgoings: Expense[];
}

export type Expense = {
    name: string;
    value: number;
}