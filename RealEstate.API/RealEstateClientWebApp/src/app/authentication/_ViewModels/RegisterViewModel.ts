export class RegisterViewModel {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;

  constructor(firstName: string = null,
    lastName: string = null,
    email: string = null,
    password: string = null,
    confirmPassword: string = null) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.password = password;
    this.confirmPassword = confirmPassword;
  }
}
