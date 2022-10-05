part of 'home_bloc.dart';

@immutable
abstract class HomeState {}

class InitialState extends HomeState {}

class FetchDataState extends HomeState {
  final List<CategoryModel> lstCate;

  FetchDataState(this.lstCate);
}
