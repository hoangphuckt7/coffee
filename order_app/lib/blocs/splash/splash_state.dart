part of 'splash_bloc.dart';

@immutable
abstract class SplashState {}

class SPInitialState extends SplashState {}

class SPLoginSuccessState extends SplashState {}

class SPLoginFailState extends SplashState {}
