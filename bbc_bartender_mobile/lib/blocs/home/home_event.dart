// ignore_for_file: prefer_typing_uninitialized_variables

part of 'home_bloc.dart';

@immutable
abstract class HomeEvent {}

class InitialEvent extends HomeEvent {}

class LoadDataEvent extends HomeEvent {}

class OrderScrollEvent extends HomeEvent {
  final showArrowTop;
  final showArrowBot;

  OrderScrollEvent(this.showArrowTop, this.showArrowBot);
}
