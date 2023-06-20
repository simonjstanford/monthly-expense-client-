export type UserExpenses = {
    user: string;
    months: ExpenseMonth[];
};

export type ExpenseMonth = {
    monthStart: Date;
    income: {};
    outgoings: {};
}