import 'package:bloc/bloc.dart';
import 'package:blue_bird_coffee_mobile/models/category/category_model.dart';
import 'package:blue_bird_coffee_mobile/repositories/category_repo.dart';
import 'package:meta/meta.dart';

part 'home_event.dart';
part 'home_state.dart';

class HomeBloc extends Bloc<HomeEvent, HomeState> {
  final _cateRepo;

  HomeBloc(this._cateRepo) : super(InitialState()) {
    // on<InitialEvent>(_onInitial);
    on<FetchDataEvent>(_onFetchData);
  }

  // Future _onInitial(InitialEvent event, Emitter<HomeState> emit) async {
  //   final lstCate = await _cateRepo.getAll();
  //   emit(InitialState(lstCate));
  // }

  Future _onFetchData(FetchDataEvent event, Emitter<HomeState> emit) async {
    final lstCate = await _cateRepo.getAll();
    emit(FetchDataState(lstCate));
  }
}
