import 'dart:developer';

import 'package:bloc/bloc.dart';
import 'package:blue_bird_coffee_mobile/models/category/category_model.dart';
import 'package:blue_bird_coffee_mobile/repositories/category_repo.dart';
import 'package:blue_bird_coffee_mobile/utils/local_storage.dart';
import 'package:meta/meta.dart';

part 'home_event.dart';
part 'home_state.dart';

class HomeBloc extends Bloc<HomeEvent, HomeState> {
  final CategoryRepo _cateRepo;

  HomeBloc(this._cateRepo) : super(InitialState()) {
    // on<InitialEvent>(_onInitial);
    on<InitialEvent>(_onInit);
  }

  // Future _onInitial(InitialEvent event, Emitter<HomeState> emit) async {
  //   final lstCate = await _cateRepo.getAll();
  //   emit(InitialState(lstCate));
  // }

  void _onInit(InitialEvent event, Emitter<HomeState> emit) async {
    emit(InitialState());
    try {
      // final lstCate = await _cateRepo.getAll();
      final token = await LocalStorage.getItem('token');
      emit(DataLoadedState(token));
    } catch (e) {
      print(e);
      emit(ErrorState("Lỗi"));
    }
  }
}
