part of 'auth_bloc.dart';

@immutable
abstract class AuthState {}

class InitState extends AuthState {}

class LoginState extends AuthState {}

class LogoutState extends AuthState {}
