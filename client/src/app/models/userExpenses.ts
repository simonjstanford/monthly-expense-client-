export type UserExpenses = {
    user: string;
    months: ExpenseMonth[];
    monthlyExpenses: MonthlyExpense[];
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

export type MonthlyExpense = {
    name: string;
    value: number;
    startDate: Date;
    endDate: Date;
}

export type AnnualExpense = {
    name: string;
    value: number;
    month: number;
    startDate: Date;
    endDate: Date;
}