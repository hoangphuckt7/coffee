part of 'home_bloc.dart';

@immutable
abstract class HomeState {}

class InitialState extends HomeState {}

class DataLoadedState extends HomeState {
  final data;

  DataLoadedState(this.data);
}

class ErrorState extends HomeState {
  final errMsg;

  ErrorState(this.errMsg);
}
