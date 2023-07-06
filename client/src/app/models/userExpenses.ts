export type UserExpenses = {
    user: string;
    months: ExpenseMonth[];
    annualExpenses: AnnualExpense[];
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

export type AnnualExpense = {
    name: string;
    value: number;
    month: number;
    startDate: Date;
    endDate: Date;
}