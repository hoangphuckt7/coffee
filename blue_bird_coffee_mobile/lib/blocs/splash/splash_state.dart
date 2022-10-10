part of 'splash_bloc.dart';

@immutable
abstract class SplashState {}

class InitialState extends SplashState {}

class LoginSuccessState extends SplashState {}

class LoginFailState extends SplashState {}
