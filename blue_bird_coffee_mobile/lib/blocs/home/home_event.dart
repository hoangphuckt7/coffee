part of 'home_bloc.dart';

@immutable
abstract class HomeEvent {}

class InitialEvent extends HomeEvent {}

class FetchDataEvent extends HomeEvent {}
