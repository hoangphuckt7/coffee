class LoginModel{

  final String phone;
  final String password;

  LoginModel(this.phone, this.password);

  Map<String, dynamic> toJson() => {
    'phone' : phone,
    'password' : password
  };
  
}