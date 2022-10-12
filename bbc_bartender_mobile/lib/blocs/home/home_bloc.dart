import 'dart:convert';
import 'dart:developer';

import 'package:bloc/bloc.dart';
import 'package:bbc_bartender_mobile/models/login/login_res_model/login_res_model.dart';
import 'package:bbc_bartender_mobile/repositories/category_repo.dart';
import 'package:bbc_bartender_mobile/repositories/floor_repo.dart';
import 'package:bbc_bartender_mobile/utils/const.dart';
import 'package:bbc_bartender_mobile/utils/local_storage.dart';
import 'package:meta/meta.dart';

part 'home_event.dart';
part 'home_state.dart';

class HomeBloc extends Bloc<HomeEvent, HomeState> {
  final CategoryRepo _cateRepo;
  final FloorRepo _floorRepo;

  HomeBloc(this._cateRepo, this._floorRepo) : super(InitialState()) {
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
      final lstCate = await _cateRepo.getAll();
      final lstFloor = await _floorRepo.getAll();
      var lrm = await LocalStorage.getItem(KeyLS.login_resp);
      var user = LoginResModel.fromJson(jsonDecode(lrm));
      emit(DataLoadedState(user.fullName! +
          " " +
          lstCate[0].description! +
          " " +
          lstFloor[0].description!));
    } catch (e) {
      print(e);
      emit(ErrorState("Lỗi"));
    }
  }
}
