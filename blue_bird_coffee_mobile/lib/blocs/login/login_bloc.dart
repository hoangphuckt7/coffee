import 'package:bloc/bloc.dart';
import 'package:blue_bird_coffee_mobile/utils/validation.dart';
import 'package:meta/meta.dart';

part 'login_event.dart';
part 'login_state.dart';

class LoginBloc extends Bloc<LoginEvent, LoginState> {
  LoginBloc() : super(LoginInitial()) {
    on<LoginUsernameChanged>(_OnUsernameInvalid);
    on<LoginPasswordChanged>(_OnPasswordInvalid);
  }

  void _OnUsernameInvalid(
      LoginUsernameChanged event, Emitter<LoginState> emit) {
    var errMsg = Validations.validUsername(event.username);
    if (errMsg != null) {
      emit(LoginUsernameInvalid(errMsg));
    }
  }

  void _OnPasswordInvalid(
      LoginPasswordChanged event, Emitter<LoginState> emit) {
    var errMsg = Validations.validPassword(event.password);
    if (errMsg != null) {
      emit(LoginPasswordInvalid(errMsg));
    }
  }
}
