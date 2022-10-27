class Host {
  static const String _localHost = 'https://localhost:7244';

  static const String _vmHost = 'https://10.0.2.2:7244';

  static const String _localIp = 'http://192.168.1.3:7244';

  static const String _dockerHost = "http://bluebirdcoffee-api/";

  static const String currentHost = _dockerHost;

  static const String currentHostApi = '$_localIp/api';
}
