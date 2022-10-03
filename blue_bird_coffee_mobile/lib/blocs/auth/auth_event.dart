part of 'auth_bloc.dart';

@immutable
abstract class AuthEvent {}

class UsernameChanged extends AuthEvent {
  final String username;

  UsernameChanged({required this.username});
}

class PasswordChanged extends AuthEvent {
  final String password;

  PasswordChanged({required this.password});
}

class LoginSubmitted extends AuthEvent {}

class LogoutSubmitted extends AuthEvent {}
