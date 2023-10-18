type ErrorResponse = {
  type: string;
  title: string;
  status: number;
  errors: {
    error: string[];
  }[];
};

export { ErrorResponse };
